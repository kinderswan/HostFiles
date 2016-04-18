﻿$(function () {
    appHostFiles.LoginPageView = Backbone.View.extend({
        events: {
            "click #login": "login"
        },
        render: function () {
            appHostFiles.utility.renderTemplate("loginPage.htm", $(this.el));
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
                console.dir(value);
            })
            .error(function () {
                alert("something gone bad");
            });
            return false;
        }
    })
})