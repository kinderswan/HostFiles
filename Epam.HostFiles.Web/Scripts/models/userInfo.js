$(function () {
    appHostFiles.UserInfo = Backbone.Model.extend({
        defaults: {
            Name: '',
            Login: '',
            Password: '',
            UserRole: ''
        }
    });

    appHostFiles.UserInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.UserInfo,
        url: 'api/users'
    });
})