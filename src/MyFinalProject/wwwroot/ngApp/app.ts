namespace MyFinalProject {

    angular.module('MyFinalProject', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: MyFinalProject.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('applicationUsers', {
                url: '/applicationUsers',
                templateUrl: '/ngApp/views/applicationUsers.html',
                controller: MyFinalProject.Controllers.ApplicationUsersController,
                controllerAs: 'controller'
            })
            .state('applicationUser', {
                url: '/applicationUsers/:id',
                templateUrl: '/ngApp/views/applicationUser.html',
                controller: MyFinalProject.Controllers.ApplicationUserController,
                controllerAs: 'controller'
            })
            .state('categories', {
                url: '/categories',
                templateUrl: '/ngApp/views/categories.html',
                controller: MyFinalProject.Controllers.CategoriesController,
                controllerAs: 'controller'
            })
            .state('category', {
                url: '/categories/:id',
                templateUrl: '/ngApp/views/category.html',
                controller: MyFinalProject.Controllers.CategoryController,
                controllerAs: 'controller'
            })
            .state('addCategory', {
                url: '/addCategory',
                templateUrl: '/ngApp/views/addCategory.html',
                controller: MyFinalProject.Controllers.AddCategoryController,
                controllerAs: 'controller'
            })
            .state('editCategory', {
                url: '/editCategory/:id',
                templateUrl: '/ngApp/views/editCategory.html',
                controller: MyFinalProject.Controllers.EditCategoryController,
                controllerAs: 'controller'
            })
            .state('addCategoryToUser', {
                url: '/addCategoryToUser/:id',
                templateUrl: '/ngApp/views/addCategoryToUser.html',
                controller: MyFinalProject.Controllers.AddCategoryToUserController,
                controllerAs: 'controller'
            })
            .state('addCategoryAndSubCategoryToUser', {
                url: '/addCategoryAndSubCategoryToUser/:id',
                templateUrl: '/ngApp/views/addCategoryAndSubCategoryToUser.html',
                controller: MyFinalProject.Controllers.AddCategoryAndSubCategoryToUserController,
                controllerAs: 'controller'
            })
            .state('subCategories', {
                url: '/subCategories',
                templateUrl: '/ngApp/views/subCategories.html',
                controller: MyFinalProject.Controllers.SubCategoriesController,
                controllerAs: 'controller'
            })
            .state('subCategory', {
                url: '/subCategories/:id',
                templateUrl: '/ngApp/views/subCategory.html',
                controller: MyFinalProject.Controllers.SubCategoryController,
                controllerAs: 'controller'
            })
            .state('addSubCategory', {
                url: '/addSubCategory',
                templateUrl: '/ngApp/views/addSubCategory.html',
                controller: MyFinalProject.Controllers.AddSubCategoryController,
                controllerAs: 'controller'
            })
            .state('editSubCategory', {
                url: '/editSubCategory/:id',
                templateUrl: '/ngApp/views/editSubCategory.html',
                controller: MyFinalProject.Controllers.EditSubCategoryController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: MyFinalProject.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: MyFinalProject.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: MyFinalProject.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: MyFinalProject.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: MyFinalProject.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('MyFinalProject').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('MyFinalProject').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
