(function (angular) {
    var fileBrowserModule = angular.module("fileBrowserModule");

    fileBrowserModule.factory("fileBrowserService", ["$http", function ($http) {

        var service = {
            getFiles: getFilesAjax,
            getFilesByPath: getFilesByPathAjax
        };

        return service;

        function getFilesAjax() {
            var promise = $http.get("api/FileBrowser/");
            return promise;
        };

        function getFilesByPathAjax(path) {
            var promise = $http.post("api/FileBrowser/", path);
            return promise;
        };

    }]);
})(angular);