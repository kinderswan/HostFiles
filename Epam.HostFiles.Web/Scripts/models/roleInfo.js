$(function () {
    appHostFiles.RoleInfo = Backbone.Model.extend({
        defaults: {
            UserRoleId: '',
            Role: '',
            RoleDescription:''
        }
    });

    appHostFiles.RoleInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.RoleInfo,
        url: "api/roles"
    });
})