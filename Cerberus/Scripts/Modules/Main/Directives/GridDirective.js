function GridDirective() {
    return {
        restrict: 'E',
        templateUrl: 'Template/Grid',
        //template: '<div ng-transclude></div>',
        //replace: true,
        scope: {
            model: '=',
            selectedItemId: '='
        },
        transclude: false,
        link: GridLinkFunction,
        controller: GridController
    }
}

function GridLinkFunction(scope, element, attr, ctrl, transcludeFn) {

}//end-of-GridLinkFunction

function GridController($scope, $element, $attrs, $transclude, $http, $filter) {
    
    $scope.Action = function (Id) { 
        //$state.go($scope.model.EditStateName, { Id: Id });
        //$scope.selectedItemId = Id;
        //$scope.action(Id);
    }

    $scope.ApplyModel = function () {
        
        $scope.PrepareModel();
        $scope.GetGrid();
        
        
    }

    $scope.Format = function(Cell) {
        if(Cell.Filter = null) {
            return Cell;
        } else {
            return $filter(Cell.Filter)(Cell)
        }
    }

    $scope.PreparePaging = function () {
        if ($scope.data.TotalRowsCount == undefined) {
            $scope.PagesArray = new Array();
        }
        var pages_count = Math.ceil($scope.data.TotalRowsCount / $scope.model.PageSize);
        var Pages = new Array();
        for (var i = 1; i <= pages_count; i++) {
            Pages.push(i);
        }
        $scope.PagesArray = Pages;
    }

    $scope.GetPageClass = function (Page) {
        if (Page == $scope.model.PageIndex) {
            return 'current-page';
        } else {
            return '';
        }
    }

    $scope.UpdatePageIndexes = function () {
        $scope.model.IndexFrom = ($scope.model.PageIndex - 1) * $scope.model.PageSize;
        $scope.model.IndexTo = $scope.model.IndexFrom + $scope.model.PageSize;
    }

    $scope.ChangePage = function (Page) {
        if (Page == $scope.model.PageIndex) {
            return;
        }
        $scope.model.PageIndex = Page;
        $scope.UpdatePageIndexes();
        $scope.GetGrid();
        //alert(Page);
    }

    $scope.PrepareData = function () {
        $scope.PreparePaging();

        for (var i = 0; i < $scope.model.Columns.length; i++) {
            for (var j = 0; j < $scope.data.ColumnNames.length; j++) {
                if ($scope.model.Columns[i].ColumnName == $scope.data.ColumnNames[j]) {
                    var filter_name = null;
                    switch ($scope.model.Columns[i].DataType) {
                        case 'Date':
                            filter_name = 'JsonDateFilter';
                            break;
                    }
                    if (filter_name != null) {
                        for (var k = 0; k < $scope.data.Rows.length; k++) {
                            $scope.data.Rows[k].Cells[j] = $filter(filter_name)($scope.data.Rows[k].Cells[j]);
                        }
                    }
                    break;
                }
            }
        }
    }

    $scope.PrepareModel = function () {
        if ($scope.data == undefined) {
            $scope.data = new Object();
        }

        if ($scope.model.PageIndex == null) {
            $scope.model.PageIndex = 1;
        }

        if ($scope.model.PageSize == null) {
            $scope.model.PageSize = 5;
        }

        //if ($scope.model.IndexFrom == null) {
        //    $scope.model.IndexFrom = 0; //default value --> trzeba wyciągnąć to gdzieś wyżej
        //}

        //if ($scope.model.IndexTo == null) {
        //    $scope.model.IndexTo = 20; //default value
        //}

        $scope.UpdatePageIndexes();

        if ($scope.model.AdditionalConditions == undefined) {
            $scope.model.AdditionalConditions = new Array();
            $scope.model.AdditionalConditions.push(null);
        }

        if( $scope.model.IdentifierColumnName == null || $scope.model.IdentifierColumnName == "" 
            || $scope.model.IdentifierColumnName == undefined) {
            $scope.ViewName = null;
        }

        if ($scope.model.ViewName == undefined || $scope.model.ViewName == "") {
            $scope.model.ViewName == null;
        }
    }

    

    $scope.GetGrid = function () {

        if ($scope.model.ViewName == null) {
            alert('GetGrid method failed!\nWrong "model" object definition...');
            return;
        }

        $http.get('api/DataProviderAPI/GetGridView', {
            params: { Param: angular.toJson($scope.model) }
        })
            .error(function (data, status, headers, config) {
                alert('error ' + status);
            })
            .success(function (data, status, headers, config) {
                $scope.data = angular.fromJson(data);
                $scope.PrepareData();
            })
        ;//end-of-$http.get
    }

    $scope.ApplyModel();

}//end-of-GridController