/// <reference path="CareerController.js" />
contentBrows.controller('contentBrowsController', ["$scope", "$window", "$routeParams", "$location", "contentBrowsService",
    function ($scope, $window, $routeParams, $location, contentBrowsService) {
        $scope.Error = "";
    	contentBrowsService.getContent("",false)
        .success(function (currentFolder) {
            $scope.CurrentFolder = currentFolder;
        })
        .error(function (error) {
        	$scope.Error = "Can't load content!!!";
        });

    	$scope.GetFolderContent = function (path) {
    	    contentBrowsService.getContent(path,false)
            .success(function (currentFolder) {
                $scope.CurrentFolder = currentFolder;
            })
            .error(function (error) {
                $scope.Error = "Can't load content!!!"
            })
    	}

    	$scope.GetParrentFolderContent = function (path) {
    	    contentBrowsService.getContent(path,true)
            .success(function (currentFolder) {
                $scope.CurrentFolder = currentFolder;
            })
            .error(function (error) {
                $scope.Error = "Can't load content!!!"
            })
    	}

    }
]);