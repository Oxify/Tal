<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Oxify.Master" CodeBehind="Cover.aspx.cs" Inherits="TalBrody.Cover" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ShowRegister() {

            var ProjectId = 1;

            var href = "Register.aspx?ProjectId=" + ProjectId;

            var txtSaveClickedHidden = '';
            var a = $(".BtnRegister").val;
            $(".BtnRegister").fancybox(
            {
                maxWidth: 516,
                maxHeight: 520,
                fitToView: false,
                width: '80%',
                height: '95%',
                autoSize: false,
                closeClick: false,
                openEffect: 'none',
                closeEffect: 'none',
                nextEffect: 'fade',
                prevEffect: 'fade',
                'href': href,
                'type': 'iframe',

                //Change title position and overlay color
                helpers:
                {
                    title:
                    {
                        type: 'inside',
                        position: 'top',
                        background: '#032f4a',
                        color: '#FFF'
                    }
                },
                beforeClose: function () {
                    //txtSaveClickedHidden = $('.fancybox-iframe').contents().find("#txtSaveClickedHidden").val();
                },
                afterClose: function () {
                    //if (true) {
                    //parent.location.reload(true);
                    //}
                }
            });

        }
    </script>
    <script type="text/javascript" src="JavaScript/Cover.js"> </script>
    <link href="Css/Cover.css" rel="stylesheet" />
    <div class="page-wrapper" id="firstpage" runat="server">
        <div class="page_with_scroll">
            <div class="page-content">
                <div class="first-page">
                    <div class="titles-part">
                        <div class="left_side">
                            <div class="title_texts">
                                <div class="Title">"עודני ילד" / חגי מרום</div>
                                <div class="SubTitle">ספר חדש ונוסטלגי</div>
                                <div class="SubTitle">על "בית הבראה לצעצועים"</div>
                            </div>
                        </div>
                        <div class="right_side">
                            <iframe class="video" src="https://www.youtube.com/embed/_urBx5_3lNY?wmode=transparent" frameborder="0" allowfullscreen></iframe>
                        </div>
                    </div>
                    <hr class="small_divider" />
                    <div class="Description">
                        בקרוב יתחיל הקמפיין לגיוס התקציב הנחוץ להפקת הספר.
					<br />
                        <b>הירשמו ותהיה הראשונים לדעת על השקת הקמפיין.</b><br />
                        לאחר שנרשמתם, הפיצו את הקמפיין ותצברו 5 ש"ח על כל חבר שנרשם בזכותכם<br />
                        לפרוייקט, אותם תוכלו לממש בקמפיין.
                    </div>
                    <a class="flat-button BtnRegister fancybox.iframe" id="BtnRegister" onclick="ShowRegister()">להרשמה</a><br />
                </div>
            </div>
            <div class="scroll-button-wrapper">
                <div class="scroll-button-div">
                <a href="#" class='ScrollButton' data-goto="secondpage"></a>
            </div>
        </div>
        </div>
    </div>
    <div class="page-wrapper1" id="secondpage">
        <div class="page-content">
            <div class="first-page">
                <div class="titles-part">
                    <div class="left_side_second">
                        <div class="title_texts">
                            <div class="Title">"עודני ילד" / חגי מרום</div>
                            <div class="SubTitle">הספר על "בית הבראה לצעצועים "</div>
                            <div>
                                "עודני ילד" הוא ספר חדש מאת חגי מרום, מעצב גרפי, צלם ובעל הוצאת הספרים "מרום תרבות ישראלית".
הספר מכיל כ- 250 צילומי צעצועים ומשחקים ישנים, אשר נבחרו בקפידה מתוך האוסף הפרטי של בני וג'ניס ירוחם.
בני וג'ניס ירוחם הקימו לפני כשנתיים את "בית הבראה לצעצועים", מוזיאון צעצועים ללא כוונות רווח, הממוקם בנמל יפו.

הספר נותן פרספקטיבה רחבה ומגוונת על צעצועי ומשחקי הילדות בארץ, החל משנות ה- 50 ועד שנות ה- 80.

בספר 20 פרקים, ובתחילת כל פרק שיר ילדים עם ברקוד שיוביל לקישור ביוטיוב.
בקישור יהיה ניתן לצפות בקליפים שיצולמו במיוחד לספר, בהם אמנים מבצעים את השירים בעיבוד המקורי שלהם.
בין האמנים שיבצעו את השירים ניתן למצוא את האחים רמירז, אורי כינורות, אלון עדר ועוד ועוד.
                            </div>
                        </div>
                        <div class="right_side_second">
                            <iframe class="video" src="https://www.youtube.com/embed/_urBx5_3lNY?wmode=transparent" frameborder="0" allowfullscreen></iframe>
                        </div>
                    </div>


                </div>
            </div>
            <div class="scroll-button-wrapper">
                <a href="#" class='ScrollButton' data-goto="thirdpage"></a>
            </div>
        </div>
    </div>
    <div class="page-wrapper">
        <div class="page-content" id="thirdpage">
            <div class="first-page">
                עוד המון תוכן על טל ברודי
                <br />
                גם תמונות וכו'
            </div>
        </div>
    </div>

</asp:Content>
