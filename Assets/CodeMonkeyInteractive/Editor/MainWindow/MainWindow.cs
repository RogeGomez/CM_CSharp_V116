using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using static CodeMonkey.CSharpCourse.Interactive.CodeMonkeyInteractiveSO;

namespace CodeMonkey.CSharpCourse.Interactive {

    public class MainWindow : EditorWindow {

        [SerializeField] private VisualTreeAsset visualTreeAsset;
        [SerializeField] private VisualTreeAsset lectureSingleVisualTreeAsset;
        [SerializeField] private VisualTreeAsset lectureHeaderVisualTreeAsset;
        [SerializeField] private VisualTreeAsset textTemplateVisualTreeAsset;
        [SerializeField] private VisualTreeAsset codeTemplateVisualTreeAsset;
        [SerializeField] private VisualTreeAsset videoTemplateVisualTreeAsset;


        private enum SubWindow {
            MainMenu,
            LectureList,
            Lecture,
        }

        private ScrollView lectureListScrollView;
        private VisualElement lectureListVisualElement;
        private VisualElement selectedLectureVisualElement;
        private VisualElement mainMenuVisualElement;
        private Vector2 lastLectureListScrollPosition;


        [MenuItem("Code Monkey/Code Monkey Main", priority = 0)]
        public static void ShowWindow() {
            MainWindow window = GetWindow<MainWindow>();
            window.titleContent = new GUIContent("Code Monkey Main");
        }

        public static void DestroyChildren(VisualElement containerVisualElement) {
            foreach (VisualElement child in containerVisualElement.Children().ToList()) {
                containerVisualElement.Remove(child);
            }
        }

        public static void AddComplexText(
            VisualTreeAsset textTemplateVisualTreeAsset,
            VisualTreeAsset codeTemplateVisualTreeAsset,
            VisualTreeAsset videoTemplateVisualTreeAsset,
            VisualElement containerVisualElement,
            string text) {
            // Break down complex text and add all components

            // ##REF##video_small, KGFAnwkO0Pk, What are Value Types and Reference Types in C#? (Class vs Struct)##REF##
            // ##REF##code, Console.WriteLine("Qwerty");##REF##

            string refTag = "##REF##";
            string textRemaining = text;
            int safety = 0;
            while (textRemaining.IndexOf(refTag) != -1 && safety < 100) {
                // Found Ref Tag
                int refTagIndex = textRemaining.IndexOf(refTag);

                // Add before text
                string textBefore = textRemaining.Substring(0, refTagIndex);
                AddText(textTemplateVisualTreeAsset, containerVisualElement, textBefore);

                string refData = textRemaining.Substring(refTagIndex + refTag.Length);
                refData = refData.Substring(0, refData.IndexOf(refTag));

                textRemaining = textRemaining.Substring(refTagIndex + refTag.Length);
                textRemaining = textRemaining.Substring(textRemaining.IndexOf(refTag) + refTag.Length);

                string[] refDataArray = refData.Split(',');
                string refType = refDataArray[0].Trim();
                switch (refType) {
                    case "video_small":
                        string youTubeId = refDataArray[1].Trim();
                        string youTubeTitle = refDataArray[2].Trim();
                        string thumbnailUrl = $"https://img.youtube.com/vi/{youTubeId}/mqdefault.jpg";
                        AddVideoReference(videoTemplateVisualTreeAsset, containerVisualElement, thumbnailUrl, youTubeTitle, "https://www.youtube.com/watch?v=" + youTubeId);
                        break;
                    case "code":
                        AddCode(codeTemplateVisualTreeAsset, containerVisualElement, refData.Substring(refType.Length + 1).Trim());
                        break;
                }
                safety++;
            }
            // No more Ref tags found
            AddText(textTemplateVisualTreeAsset, containerVisualElement, textRemaining);
        }

        public static void AddText(VisualTreeAsset textTemplateVisualTreeAsset, VisualElement containerVisualElement, string text) {
            VisualElement textVisualElement = textTemplateVisualTreeAsset.Instantiate();

            Label textLabel = textVisualElement.Q<Label>("textLabel");
            textLabel.text = text;

            containerVisualElement.Add(textVisualElement);
        }

        public static void AddCode(VisualTreeAsset codeTemplateVisualTreeAsset, VisualElement containerVisualElement, string codeString) {
            VisualElement codeVisualElement = codeTemplateVisualTreeAsset.Instantiate();

            Label textLabel = codeVisualElement.Q<Label>("codeLabel");
            textLabel.text = codeString;

            containerVisualElement.Add(codeVisualElement);
        }

        public static void AddVideoReference(VisualTreeAsset videoTemplateVisualTreeAsset, VisualElement containerVisualElement, string imageUrl, string title, string url, VideoReferenceSettings videoReferenceSettings = null) {
            Sprite waitingSprite = null;
            VisualElement videoVisualElement = AddVideoReference(videoTemplateVisualTreeAsset, containerVisualElement, waitingSprite, title, url, videoReferenceSettings);

            UnityWebRequest unityWebRequest = UnityWebRequestTexture.GetTexture(imageUrl);
            unityWebRequest.SendWebRequest().completed += (AsyncOperation asyncOperation) => {
                try {
                    UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = asyncOperation as UnityWebRequestAsyncOperation;

                    if (unityWebRequestAsyncOperation.webRequest.result == UnityWebRequest.Result.ConnectionError ||
                        unityWebRequestAsyncOperation.webRequest.result == UnityWebRequest.Result.DataProcessingError ||
                        unityWebRequestAsyncOperation.webRequest.result == UnityWebRequest.Result.ProtocolError) {
                        // Error
                        //onError(unityWebRequest.error);
                    } else {
                        DownloadHandlerTexture downloadHandlerTexture = unityWebRequest.downloadHandler as DownloadHandlerTexture;
                        VisualElement imageVisualElement = videoVisualElement.Q<VisualElement>("image");
                        imageVisualElement.style.backgroundImage = new StyleBackground(downloadHandlerTexture.texture);
                    }
                } catch (Exception) {
                }
                unityWebRequest.Dispose();
            };
        }

        public static VisualElement AddVideoReference(VisualTreeAsset videoTemplateVisualTreeAsset, VisualElement containerVisualElement, Sprite sprite, string title, string url, VideoReferenceSettings videoReferenceSettings = null) {
            VisualElement videoVisualElement = videoTemplateVisualTreeAsset.Instantiate();

            VisualElement videoContainer = videoVisualElement.Q<VisualElement>("videoContainer");
            videoContainer.RegisterCallback<ClickEvent>((ClickEvent clickEvent) => {
                Debug.Log("Clicked: " + url);
                Application.OpenURL(url);
            });

            VisualElement imageVisualElement = videoContainer.Q<VisualElement>("image");
            imageVisualElement.style.backgroundImage = new StyleBackground(sprite);

            Label textLabel = videoContainer.Q<Label>("titleLabel");
            textLabel.text = title;

            if (videoReferenceSettings != null) {
                if (videoReferenceSettings.height != null) {
                    imageVisualElement.style.height = new StyleLength(videoReferenceSettings.height.Value);
                }
                if (videoReferenceSettings.fontSize != null) {
                    textLabel.style.fontSize = new StyleLength(videoReferenceSettings.fontSize.Value);
                }
            }

            containerVisualElement.Add(videoVisualElement);

            return videoVisualElement;
        }

        public class VideoReferenceSettings {
            public float? height;
            public float? fontSize;
        }

        private SubWindow GetActiveSubWindow() {
            if (lectureListVisualElement.style.display == DisplayStyle.Flex) {
                return SubWindow.LectureList;
            }
            if (selectedLectureVisualElement.style.display == DisplayStyle.Flex) {
                return SubWindow.Lecture;
            }
            return SubWindow.MainMenu;
        }

        public void OnDestroy() {
            CodeMonkeyInteractiveSO.GetCodeMonkeyInteractiveSO().OnStateChanged -= CodeMonkeyInteractiveSO_OnStateChanged;
        }

        private void CodeMonkeyInteractiveSO_OnStateChanged(object sender, EventArgs e) {
            switch (GetActiveSubWindow()) {
                case SubWindow.MainMenu:
                    ShowMainMenu();
                    break;
                case SubWindow.LectureList:
                    ShowLectureButtons();
                    break;
                case SubWindow.Lecture:
                    ShowLecture();
                    break;
            }
        }

        public void CreateGUI() {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;

            CodeMonkeyInteractiveSO.GetCodeMonkeyInteractiveSO().OnStateChanged -= CodeMonkeyInteractiveSO_OnStateChanged;
            CodeMonkeyInteractiveSO.GetCodeMonkeyInteractiveSO().OnStateChanged += CodeMonkeyInteractiveSO_OnStateChanged;

            // Instantiate UXML
            VisualElement rootVisualTreeAsset = visualTreeAsset.Instantiate();
            rootVisualTreeAsset.style.flexGrow = 1f;
            root.Add(rootVisualTreeAsset);

            lectureListScrollView = root.Q<ScrollView>("lectureListScrollView");
            lectureListVisualElement = root.Q<VisualElement>("lectureList");
            selectedLectureVisualElement = root.Q<VisualElement>("selectedLectureContainer");
            mainMenuVisualElement = root.Q<VisualElement>("mainMenu");

            root.Q<Label>("versionLabel").text = CodeMonkeyInteractiveSO.GetCodeMonkeyInteractiveSO().currentVersion;

            Button lectureListButton = mainMenuVisualElement.Q<Button>("lectureListButton");
            lectureListButton.RegisterCallback((ClickEvent clickEvent) => {
                ShowLectureButtons();
            });

            Button backToMainMenuButton = lectureListVisualElement.Q<Button>("backToMainMenuButton");
            backToMainMenuButton.RegisterCallback((ClickEvent clickEvent) => {
                ShowMainMenu();
            });


            ObjectField objectField = rootVisualElement.Q<ObjectField>("scriptableObjectField");
            objectField.RegisterValueChangedCallback((ChangeEvent<UnityEngine.Object> evt) => {
                ShowLecture();
            });

            Button backToLectureListButton = selectedLectureVisualElement.Q<Button>("backButton");
            backToLectureListButton.RegisterCallback((ClickEvent clickEvent) => {
                ObjectField objectField = rootVisualElement.Q<ObjectField>("scriptableObjectField");
                objectField.value = null;
                ShowLectureButtons();
            });

            lectureListScrollView.RegisterCallback((GeometryChangedEvent evt) => {
                lectureListScrollView.scrollOffset = lastLectureListScrollPosition;
            });

            ShowMainMenu();
        }

        private void ShowMainMenu() {
            lectureListVisualElement.style.display = DisplayStyle.None;
            selectedLectureVisualElement.style.display = DisplayStyle.None;
            mainMenuVisualElement.style.display = DisplayStyle.Flex;

            // Check for updates
            CodeMonkeyInteractiveSO.CheckForUpdates((string currentVersion, string newVersion) => {
                if (currentVersion == newVersion) {
                    mainMenuVisualElement.Q<VisualElement>("checkingForUpdates").style.display = DisplayStyle.None;
                    return;
                }

                VisualElement checkingForUpdatesVisualElement =
                    mainMenuVisualElement.Q<VisualElement>("checkingForUpdates");
                checkingForUpdatesVisualElement.style.display = DisplayStyle.Flex;
                Label textLabel = checkingForUpdatesVisualElement.Q<Label>();
                textLabel.text = "New version available!\n" +
                    currentVersion + " -> " + newVersion + "\n" +
                    "<u>Click here!</u>";

                textLabel.RegisterCallback((ClickEvent clickEvent) => {
                    string url = "https://unitycodemonkey.teachable.com/courses/learn-c-from-beginner-to-advanced/lectures/52372827";
                    Application.OpenURL(url);
                });
            });


            // Totals
            VisualElement totalsVisualElement =
                mainMenuVisualElement.Q<VisualElement>("totals");

            Label totalsLabel = totalsVisualElement.Q<Label>("totalsLabel");

            CodeMonkeyInteractiveSO.GetCompletionStats(
                out int faqCompleted, out int faqTotals,
                out int quizCompleted, out int quizTotals,
                out int exercisesCompleted, out int exercisesTotals);

            totalsLabel.text = $"FAQ: {faqCompleted} / {faqTotals}\n" +
                $"Quiz: {quizCompleted} / {quizTotals}\n" +
                $"Exercises: {exercisesCompleted} / {exercisesTotals}";


            // Message
            VisualElement messageVisualElement =
                mainMenuVisualElement.Q<VisualElement>("message");

            CodeMonkeyInteractiveSO.GetLatestMessage((WebsiteLatestMessage websiteLatestMessage) => {
                messageVisualElement.Q<Label>("messageLabel").text = websiteLatestMessage.text;
            });



            // QOTD
            VisualElement qotdVisualElement =
                mainMenuVisualElement.Q<VisualElement>("qotd");

            Action openQotdURL = () => {
                string qotdUrl = "https://unitycodemonkey.com/qotd_ask.php?q=30";
                Application.OpenURL(qotdUrl);
            };
            qotdVisualElement.RegisterCallback((ClickEvent clickEvent) => {
                openQotdURL();
            });

            qotdVisualElement.Q<Label>("questionLabel").text = "...";
            qotdVisualElement.Q<Button>("answerAButton").style.display = DisplayStyle.None;
            qotdVisualElement.Q<Button>("answerBButton").style.display = DisplayStyle.None;
            qotdVisualElement.Q<Button>("answerCButton").style.display = DisplayStyle.None;
            qotdVisualElement.Q<Button>("answerDButton").style.display = DisplayStyle.None;
            qotdVisualElement.Q<Button>("answerEButton").style.display = DisplayStyle.None;

            CodeMonkeyInteractiveSO.GetLastQOTD((CodeMonkeyInteractiveSO.LastQOTDResponse lastQOTDResponse) => {
                openQotdURL = () => {
                    string qotdUrl = "https://unitycodemonkey.com/qotd_ask.php?q=" + lastQOTDResponse.questionId;
                    Application.OpenURL(qotdUrl);
                };

                qotdVisualElement.Q<Label>("questionLabel").text = lastQOTDResponse.questionText;
                if (!string.IsNullOrEmpty(lastQOTDResponse.answerA)) {
                    qotdVisualElement.Q<Button>("answerAButton").style.display = DisplayStyle.Flex;
                    qotdVisualElement.Q<Button>("answerAButton").text = lastQOTDResponse.answerA;
                }
                if (!string.IsNullOrEmpty(lastQOTDResponse.answerB)) {
                    qotdVisualElement.Q<Button>("answerBButton").style.display = DisplayStyle.Flex;
                    qotdVisualElement.Q<Button>("answerBButton").text = lastQOTDResponse.answerB;
                }
                if (!string.IsNullOrEmpty(lastQOTDResponse.answerC)) {
                    qotdVisualElement.Q<Button>("answerCButton").style.display = DisplayStyle.Flex;
                    qotdVisualElement.Q<Button>("answerCButton").text = lastQOTDResponse.answerC;
                }
                if (!string.IsNullOrEmpty(lastQOTDResponse.answerD)) {
                    qotdVisualElement.Q<Button>("answerDButton").style.display = DisplayStyle.Flex;
                    qotdVisualElement.Q<Button>("answerDButton").text = lastQOTDResponse.answerD;
                }
                if (!string.IsNullOrEmpty(lastQOTDResponse.answerE)) {
                    qotdVisualElement.Q<Button>("answerEButton").style.display = DisplayStyle.Flex;
                    qotdVisualElement.Q<Button>("answerEButton").text = lastQOTDResponse.answerE;
                }
            });


            // Dynamic Message
            VisualElement dynamicMessageVisualElement =
                mainMenuVisualElement.Q<VisualElement>("dynamicMessage");

            Func<string> getDynamicMessageURL = () => "https://unitycodemonkey.com/";
            dynamicMessageVisualElement.RegisterCallback((ClickEvent clickEvent) => {
                Application.OpenURL(getDynamicMessageURL());
            });

            CodeMonkeyInteractiveSO.GetWebsiteDynamicMessage((WebsiteDynamicMessage websiteDynamicMessage) => {
                dynamicMessageVisualElement.Q<Label>("messageLabel").text = websiteDynamicMessage.text;
                getDynamicMessageURL = () => websiteDynamicMessage.url;
            });


            // Latest Videos
            VisualElement latestVideosVisualElement =
                mainMenuVisualElement.Q<VisualElement>("latestVideos");

            latestVideosVisualElement.Q<VisualElement>("_1Container").Clear();
            latestVideosVisualElement.Q<VisualElement>("_2Container").Clear();
            latestVideosVisualElement.Q<VisualElement>("_3Container").Clear();
            latestVideosVisualElement.Q<VisualElement>("_4Container").Clear();



            CodeMonkeyInteractiveSO.GetWebsiteLatestVideos((LatestVideos latestVideos) => {
                AddLatestVideoReference(latestVideos.videos[0], latestVideosVisualElement.Q<VisualElement>("_1Container"));
                AddLatestVideoReference(latestVideos.videos[1], latestVideosVisualElement.Q<VisualElement>("_2Container"));
                AddLatestVideoReference(latestVideos.videos[2], latestVideosVisualElement.Q<VisualElement>("_3Container"));
                AddLatestVideoReference(latestVideos.videos[3], latestVideosVisualElement.Q<VisualElement>("_4Container"));
            });

            void AddLatestVideoReference(LatestVideoSingle latestVideoSingle, VisualElement containerVisualElement) {
                string thumbnailUrl = $"https://img.youtube.com/vi/{latestVideoSingle.youTubeId}/mqdefault.jpg";
                string url = $"https://unitycodemonkey.com/video.php?v={latestVideoSingle.youTubeId}";
                AddVideoReference(
                    videoTemplateVisualTreeAsset,
                    containerVisualElement,
                    thumbnailUrl,
                    latestVideoSingle.title,
                    url,
                    new VideoReferenceSettings {
                        height = 80,
                        fontSize = 9,
                    }
                );
            }

            //PrintAllTitles();
            //WriteFileAllTextData();

            if (CodeMonkeyInteractiveSO.TryLoad()) {
                ShowMainMenu();
            }
        }

        private void PrintAllTitles() {
            CodeMonkeyInteractiveSO codeMonkeyInteractiveSO = CodeMonkeyInteractiveSO.GetCodeMonkeyInteractiveSO();
            foreach (LectureSO lectureSO in codeMonkeyInteractiveSO.lectureListSO.lectureSOList) {
                if (lectureSO.GetLectureSection() == LectureSO.Section.Beginner) {
                    continue;
                }
                if (lectureSO.GetLectureSection() == LectureSO.Section.Intermediate) {
                    continue;
                }
                Debug.Log("Lecture " + lectureSO.lectureCode);
                string faq = "";
                string exercises = "";
                string quiz = "";
                foreach (FrequentlyAskedQuestionSO frequentlyAskedQuestionSO in lectureSO.frequentlyAskedQuestionListSO.frequentlyAskedQuestionSOList) {
                    faq += frequentlyAskedQuestionSO.title + "\n\n";
                }
                foreach (ExerciseSO exerciseSO in lectureSO.exerciseListSO.exerciseSOList) {
                    exercises += exerciseSO.exerciseTitle + "\n\n";
                }
                foreach (QuizSO quizSO in lectureSO.quizListSO.quizSOList) {
                    quiz += quizSO.question + "\n\n";
                }
                Debug.Log(faq);
                Debug.Log(exercises);
                Debug.Log(quiz);
                Debug.Log("------------");
            }
        }

        private void WriteFileAllTextData() {
            string text = "";
            CodeMonkeyInteractiveSO codeMonkeyInteractiveSO = CodeMonkeyInteractiveSO.GetCodeMonkeyInteractiveSO();
            foreach (LectureSO lectureSO in codeMonkeyInteractiveSO.lectureListSO.lectureSOList) {
                text += "####### Lecture " + lectureSO.lectureName + "\n\n";
                string faq = "";

                foreach (FrequentlyAskedQuestionSO frequentlyAskedQuestionSO in lectureSO.frequentlyAskedQuestionListSO.frequentlyAskedQuestionSOList) {
                    faq += "FAQ: " + frequentlyAskedQuestionSO.title + "\n";
                    faq += frequentlyAskedQuestionSO.text + "\n\n\n";
                }
                /*
                foreach (QuizSO quizSO in lectureSO.quizListSO.quizSOList) {
                    quiz += "QUIZ: " + quizSO.question + "\n";
                    quiz += quizSO.correctOptionIndex + "\n\n";
                    quiz += quizSO.answer + "\n\n";
                }*/
                text += "#### FREQUENTLY ASKED QUESTIONS" + "\n";
                text += faq;

                text += "------------\n\n\n\n";
            }
            File.WriteAllText(Application.dataPath + "/courseCSharpFAQ.txt", text);
        }

        private void ShowLectureButtons() {
            lectureListVisualElement.style.display = DisplayStyle.Flex;
            selectedLectureVisualElement.style.display = DisplayStyle.None;
            mainMenuVisualElement.style.display = DisplayStyle.None;

            // Remove old questions
            MainWindow.DestroyChildren(lectureListScrollView);

            // Spawn Lectures
            LectureSO lastLectureSO = null;
            foreach (LectureSO lectureSO in LectureListSO.GetLectureListSO().lectureSOList) {
                if (lastLectureSO == null) {
                    // First lecture
                    VisualElement lectureHeader = lectureHeaderVisualTreeAsset.Instantiate();
                    lectureListScrollView.Add(lectureHeader);
                    lectureHeader.Q<Label>().text = "BEGINNER";
                } else {
                    if (lastLectureSO.GetLectureSection() != lectureSO.GetLectureSection()) {
                        // Different section
                        VisualElement lectureHeader = lectureHeaderVisualTreeAsset.Instantiate();
                        lectureListScrollView.Add(lectureHeader);
                        lectureHeader.Q<Label>().text = lectureSO.GetLectureSection().ToString().ToUpper();
                    }
                }
                VisualElement lectureSingle = lectureSingleVisualTreeAsset.Instantiate();
                lectureSingle.name = "lectureSingle_" + lectureSO.name;

                lectureSO.GetLectureStats(out int faqDone,
                    out int faqTotal,
                    out int quizDone,
                    out int quizTotal,
                    out int exercisesDone,
                    out int exercisesTotal);

                Label completionStatsLabel = lectureSingle.Q<Label>("completionStatsLabel");
                completionStatsLabel.text = 
                    (faqDone + quizDone + exercisesDone) + " / " +
                    (faqTotal + quizTotal + exercisesTotal);

                bool allDone =
                    (faqDone + quizDone + exercisesDone) >=
                    (faqTotal + quizTotal + exercisesTotal);

                if (allDone) {
                    completionStatsLabel.text = $"<color=#00ff00>{completionStatsLabel.text}</color>";
                }

                lectureSingle.Q<Button>("button").text = lectureSO.lectureSectionNumber + ". " + lectureSO.lectureTitle;
                lectureSingle.RegisterCallback<ClickEvent>((ClickEvent clickEvent) => {
                    lastLectureListScrollPosition = lectureListScrollView.scrollOffset;
                    ObjectField objectField = rootVisualElement.Q<ObjectField>("scriptableObjectField");
                    objectField.value = lectureSO;
                });

                lectureListScrollView.Add(lectureSingle);

                lastLectureSO = lectureSO;
            }
            lectureListScrollView.schedule.Execute(() => {
                lectureListScrollView.scrollOffset = lastLectureListScrollPosition;
            });
            lectureListScrollView.scrollOffset = lastLectureListScrollPosition;
        }

        private void ShowLecture() {
            ObjectField objectField = rootVisualElement.Q<ObjectField>("scriptableObjectField");
            if (objectField.value != null) {
                LectureSO lectureSO = objectField.value as LectureSO;
                ShowLecture(lectureSO);
            }
        }

        private void ShowLecture(LectureSO lectureSO) {
            CodeMonkeyInteractiveSO.SetLastSelectedLectureSO(lectureSO);

            lectureListVisualElement.style.display = DisplayStyle.None;
            selectedLectureVisualElement.style.display = DisplayStyle.Flex;
            mainMenuVisualElement.style.display = DisplayStyle.None;

            Button frequentlyAskedQuestionButton = selectedLectureVisualElement.Q<Button>("frequentlyAskedQuestionButton");
            Button quizButton = selectedLectureVisualElement.Q<Button>("quizButton");
            Button exercisesButton = selectedLectureVisualElement.Q<Button>("exercisesButton");
            Button startProjectButton = selectedLectureVisualElement.Q<Button>("startProjectButton");

            if (lectureSO.isProject) {
                // Is project, hide other buttons
                frequentlyAskedQuestionButton.style.display = DisplayStyle.None;
                quizButton.style.display = DisplayStyle.None;
                exercisesButton.style.display = DisplayStyle.None;
                startProjectButton.style.display = DisplayStyle.Flex;
            } else {
                // Not a project, hide project button
                frequentlyAskedQuestionButton.style.display = DisplayStyle.Flex;
                quizButton.style.display = DisplayStyle.Flex;
                exercisesButton.style.display = DisplayStyle.Flex;
                startProjectButton.style.display = DisplayStyle.None;
            }

            LectureSO.LectureStats lectureStats = lectureSO.GetLectureStats();

            frequentlyAskedQuestionButton.text = $"FAQ ({lectureStats.faqDone}/{lectureStats.faqTotal})";
            quizButton.text = $"Quiz ({lectureStats.quizDone}/{lectureStats.quizTotal})";
            exercisesButton.text = $"Exercises ({lectureStats.exercisesDone}/{lectureStats.exercisesTotal})";

            frequentlyAskedQuestionButton.RegisterCallback((ClickEvent clickEvent) => {
                GetWindow<FrequentlyAskedQuestionsWindow>().SetLectureSO(lectureSO);
            });
            quizButton.RegisterCallback((ClickEvent clickEvent) => {
                GetWindow<QuizWindow>().SetLectureSO(lectureSO);
            });
            exercisesButton.RegisterCallback((ClickEvent clickEvent) => {
                GetWindow<ExercisesWindow>().SetLectureSO(lectureSO);
            });

            if (lectureSO.isProject) {
                startProjectButton.RegisterCallback((ClickEvent clickEvent) => {
                    string lectureFolder = $"{lectureSO.lectureCode}_{lectureSO.lectureName}";
                    string projectFolderPath = Application.dataPath +
                        $"/Projects/{lectureFolder}/";

                    string filePath = projectFolderPath + lectureFolder + "_GameScene.unity";
                    if (File.Exists(filePath)) {
                        filePath = filePath.Substring(Application.dataPath.Length);
                        filePath = "Assets" + filePath;
                        EditorSceneManager.OpenScene(filePath);
                    }

                    filePath = projectFolderPath + lectureSO.lectureName + ".cs";
                    if (File.Exists(filePath)) {
                        filePath = filePath.Substring(Application.dataPath.Length);
                        filePath = "Assets" + filePath;
                        EditorGUIUtility.PingObject(AssetDatabase.LoadMainAssetAtPath(filePath));
                        AssetDatabase.OpenAsset(AssetDatabase.LoadMainAssetAtPath(filePath));
                    }
                });
            }
        }

    }

}