(function (angular) {
    var fileBrowserModule = angular.module("fileBrowserModule");

    fileBrowserModule.factory("fileBrowserService", ["$http", function ($http) {

        var service = {
            getFiles: getFilesAjax,
            getFilesByPath: getFilesByPathAjax
        };

        return service;

        function getFilesAjax() {
            var promise = $http.get("../api/FileBrowser/");
            return promise;
        };

        function getFilesByPathAjax(_path) {
            var data = { path: _path};
            var promise = $http.post("../api/FileBrowser/", data);
            return promise;
        };

    }]);
})(angular);