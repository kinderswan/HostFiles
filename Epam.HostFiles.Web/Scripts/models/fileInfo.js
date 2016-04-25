$(function () {
    appHostFiles.FileInfo = Backbone.Model.extend({
        defaults: {
            FileName: '',
            Path: '',
            Size: ''
        }
    });
    appHostFiles.FileInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.FileInfo,
        url: '',
        comparator: function (file) {
            return file.get("FileName");
        }
    });
})