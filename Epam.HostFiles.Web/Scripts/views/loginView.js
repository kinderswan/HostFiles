$(function () {
    appHostFiles.LoginPageView = Backbone.View.extend({
        events: {
            "click #login-button": "login"
        },
        render: function () {
            appHostFiles.utility.renderTemplate("loginPage.html", $(this.el));
        },
        login: function () {
            var data = appHostFiles.utility.serializeObject($("#loginPageForm"));
            $.ajax({
                url: "api/login",
                data: JSON.stringify(data),
                type: "POST",
                datatype: 'json',
                contentType: 'application/json'
            })
            .success(function (value) {
                appHostFiles.App.navigate('', { trigger: true });
            })
            .error(function () {
                alert("something going bad");
            });
            return false;
        }
    })
})