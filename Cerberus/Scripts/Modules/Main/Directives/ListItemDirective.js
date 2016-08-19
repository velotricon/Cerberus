function ListItemDirective() {
    return {
        //template: '<div class="list-item">{{text}}</div>',
        template: '',
        restrict: 'E',
        transclude: true,
        require: '^list',
        scope: {
            text: '@'
        },
        link: ListItemLinkFunction,
        controller: ListItemController
    }
}

function ListItemLinkFunction(scope, element, attrs, ctrl, transcludeFn) {

}

function ListItemController($scope, $element, $attrs, $transclude, $rootScope) {
    $scope.x = 'a1';
    $scope.$parent.RegisterListItem($scope.text);
}