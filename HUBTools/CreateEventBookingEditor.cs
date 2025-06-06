using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace BrandLab360.Editor
{

    public class CreateEventBookingEditor : CreateBaseEditor
    {
        // [MenuItem("BrandLab360/Core/Event Booking/Button")]

#if BRANDLAB360_INTERNAL
        public static void CreateButton()
        {
            RectTransform rectT = null;

            Canvas goCanvas = new GameObject().AddComponent<Canvas>();
            CanvasScaler goCanvasScaler = goCanvas.gameObject.AddComponent<CanvasScaler>();
            GraphicRaycaster goRaycaster = goCanvas.gameObject.AddComponent<GraphicRaycaster>();
            goCanvas.gameObject.AddComponent<BoxCollider>().size = new Vector3(0.25f, 0.25f, 0.025f);
            goRaycaster.ignoreReversedGraphics = false;

            goCanvas.name = "CanvasBooking_";
            rectT = goCanvas.GetComponent<RectTransform>();
            rectT.anchorMin = Vector2.zero;
            rectT.anchorMax = Vector2.zero;
            rectT.localScale = new Vector3(1f, 1f, 0.25f);
            rectT.localPosition = Vector3.zero;
            rectT.sizeDelta = new Vector2(0.25f, 0.25f);

            goCanvas.additionalShaderChannels |= AdditionalCanvasShaderChannels.Normal;
            goCanvas.additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord1;
            goCanvas.additionalShaderChannels |= AdditionalCanvasShaderChannels.Tangent;


            EventBooking bookingScript = goCanvas.gameObject.AddComponent<EventBooking>();

            Image goButton = new GameObject().AddComponent<Image>();
            goButton.name = "Button_EventBooking";
            goButton.GetComponent<CanvasRenderer>().cullTransparentMesh = false;

            goCanvas.additionalShaderChannels |= AdditionalCanvasShaderChannels.TexCoord1 | AdditionalCanvasShaderChannels.TexCoord2 | AdditionalCanvasShaderChannels.TexCoord3;

            goButton.transform.SetParent(goCanvas.transform);
            rectT = goButton.GetComponent<RectTransform>();
            rectT.anchorMin = Vector2.zero;
            rectT.anchorMax = Vector2.one;
            rectT.pivot = new Vector2(0.5f, 0.5f);
            rectT.offsetMax = new Vector2(0, 0);
            rectT.offsetMin = new Vector2(0, 0);
            rectT.localScale = Vector3.one;

            Button buttonScript = goButton.gameObject.AddComponent<Button>();
            Navigation nav = new Navigation();
            nav.mode = Navigation.Mode.None;
            buttonScript.navigation = nav;

            Image buttonImage = new GameObject().AddComponent<Image>();
            buttonImage.color = new Color(0, 0, 0, 1);

            UnityEngine.Object[] atlas = GetAssets("Assets/com.brandlab360.core/Runtime/Sprites/World/Wolrd_Icons_3.png");

            for (int i = 0; i < atlas.Length; i++)
            {
                if (atlas[i].name.Contains("IconCalender"))
                {
                    buttonImage.sprite = (Sprite)atlas[i];

                    break;
                }
            }

            buttonImage.name = "Icon_Calender";
            buttonImage.transform.SetParent(goButton.transform);
            rectT = buttonImage.GetComponent<RectTransform>();
            rectT.anchorMin = Vector2.zero;
            rectT.anchorMax = Vector2.one;
            rectT.pivot = new Vector2(0.5f, 0.5f);
            rectT.offsetMax = new Vector2(-0.05f, -0.05f);
            rectT.offsetMin = new Vector2(0.05f, 0.05f);
            rectT.localScale = new Vector3(1, 1, 1);

            AppConstReferences settings = Resources.Load<AppConstReferences>("AppConstReferences");
            ButtonTheme theme = goButton.gameObject.AddComponent<ButtonTheme>();

            if (settings != null)
            {
                int index = 0;

                for (int i = 0; i < settings.Settings.themeSettings.buttonThemes.Count; i++)
                {
                    if (settings.Settings.themeSettings.buttonThemes[i].id.Equals("White"))
                    {
                        index = i;
                        break;
                    }
                }

                theme.Apply(settings.Settings.themeSettings, index);
            }

            ButtonAppearance bApperance = goButton.gameObject.AddComponent<ButtonAppearance>();
            bApperance.Apply(ButtonAppearance.Appearance._Round);

            CreateParentAndSelectObject("_EVENTBOOKING", goCanvas.transform);
        }
#endif
    }
}
