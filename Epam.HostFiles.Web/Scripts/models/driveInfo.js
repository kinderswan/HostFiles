$(function () {
    appHostFiles.DriveInfo = Backbone.Model.extend({
        defaults: {
            _name: ''
        }
    });

    appHostFiles.DriveInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.DriveInfo,
        url: "api/drives"
    });
})