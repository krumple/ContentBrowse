contentBrows.factory('contentBrowsService', ["$http", "$location", function ($http, $location) {

    return {
        getContent: function (path,parrent) { return $http.get("/api/FileBrowseWebApi/Get?path=" + path +"&&parrent="+ parrent) },
    };
}]);