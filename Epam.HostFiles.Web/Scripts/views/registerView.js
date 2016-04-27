$(function () {
    appHostFiles.RegisterPageView = Backbone.View.extend({
        events: {
            "click #register-button": "register"
        },
        render: function () {
            appHostFiles.utility.renderTemplate("registerPage.html", $(this.el));
        },
        register: function () {
            var data = appHostFiles.utility.serializeObject($("#registerPageForm"));
            $.ajax({
                url: "api/register",
                data: JSON.stringify(data),
                type: "POST",
                datatype: 'json',
                contentType: 'application/json'
            })
            .success(function (value) {
                appHostFiles.App.navigate('', { trigger: true });
            })
            .error(function (data) {
                if (data.status == 409) {
                    alert(JSON.parse(data.responseText).Message);
                }
            });
            return false;
        }

    })
})