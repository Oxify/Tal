<%@ Page Title="" Language="C#" MasterPageFile="~/Oxify.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="TalBrody.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="full-page">
        <div class="container main-content">
            <div class="row">
                <div class="col-xs-12 col-sm-10 col-sm-push-1">
                    <div id="wufoo-z1ozjjqh1bxcj62">
                        Fill out my <a href="https://oxify.wufoo.com/forms/z1ozjjqh1bxcj62">online form</a>.
                    </div>
                    <div id="wuf-adv" style="font-family: inherit; font-size: small; color: #a7a7a7; text-align: center; display: none;">Use <a href="http://www.wufoo.com/gallery/templates/">Wufoo templates</a> to make your own HTML forms.</div>
                    <script type="text/javascript">var z1ozjjqh1bxcj62; (function (d, t) {
    var s = d.createElement(t), options = {
        'userName': 'oxify',
        'formHash': 'z1ozjjqh1bxcj62',
        'autoResize': true,
        'height': '560',
        'async': true,
        'host': 'wufoo.com',
        'header': 'show',
        'ssl': true
    };
    s.src = ('https:' == d.location.protocol ? 'https://' : 'http://') + 'www.wufoo.com/scripts/embed/form.js';
    s.onload = s.onreadystatechange = function () {
        var rs = this.readyState; if (rs) if (rs != 'complete') if (rs != 'loaded') return;
        try { z1ozjjqh1bxcj62 = new WufooForm(); z1ozjjqh1bxcj62.initialize(options); z1ozjjqh1bxcj62.display(); } catch (e) { }
    };
    var scr = d.getElementsByTagName(t)[0], par = scr.parentNode; par.insertBefore(s, scr);
})(document, 'script');</script>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
