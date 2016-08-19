var MainApp = angular.module('MainApp', ["ngRoute"]);

//Constants:
MainApp.constant('baseUrl', 'http://localhost:7070/');
//end-of-Costants

//Configuration:
MainApp.config(ConfigFunction);
//end-of-Configuration

//Controllers:
MainApp.controller('MainController', MainController);
MainApp.controller('PersonListController', PersonListController);
MainApp.controller('AddTranslationController', AddTranslationController);
//end-of-Controllers

//Directives:
MainApp.directive('crbLightComboBox', LightComboBoxDirective);
//end-of-Directives
