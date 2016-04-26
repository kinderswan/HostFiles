$(function () {
    appHostFiles.LogoutPageView = Backbone.View.extend({
        events: {
            "click #logout": "logout"
        },
        render: function () {
            appHostFiles.utility.renderTemplate("logoutPage.html", $(this.el));
        },
        logout: function () {
            $.ajax({
                url: "api/logout",
                type: "POST"
            })
            .success(function (value) {
                $("#navbar").empty();
                appHostFiles.App.navigate("index", { trigger: true });
            });
            return false;
        }
    });

})