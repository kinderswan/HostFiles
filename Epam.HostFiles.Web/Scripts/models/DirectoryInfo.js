$(function () {
    appHostFiles.DirectoryInfo = Backbone.Model.extend({
        defaults: {
            directoryName: ''
        }
    });

    appHostFiles.DirectoryInfoCollection = Backbone.Collection.extend({
        model: window.appHostFiles.DirectoryInfo,
        url: "",
        comparator: function (dir) {
            return dir.get("directoryName");
        }
    });
})