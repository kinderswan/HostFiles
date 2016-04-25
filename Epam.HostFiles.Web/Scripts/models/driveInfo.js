$(function () {
    appHostFiles.DriveInfo = Backbone.Model.extend({
        defaults: {
            DriveName: ''
        }
    });

    appHostFiles.DriveInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.DriveInfo,
        url: "api/drives"
    });
})