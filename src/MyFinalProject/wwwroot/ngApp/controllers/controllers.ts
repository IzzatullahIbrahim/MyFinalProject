namespace MyFinalProject.Controllers {

    export class HomeController {
        public message = 'Hello from the home page';
    }

    export class ApplicationUsersController {
        public message = 'Hello from the users page!';
        public appUsers;

        constructor(private $http: ng.IHttpService) {
            this.$http.get('/api/applicationUsers').then((response) => {
                this.appUsers = response.data;
            })
        }
    }

    export class ApplicationUserController {
        public message = 'Hello from the user page';
        public appUser;

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {
            let userId = this.$stateParams['id'];

            this.$http.get('/api/applicationUsers/' + userId).then((response) => {
                this.appUser = response.data;
            })
        }
    }

    export class CategoriesController {
        public message = 'Hello from categories page';
        public categories;

        constructor(private $http: ng.IHttpService) {
            this.$http.get('/api/categories').then((response) => {
                this.categories = response.data;
            })
        }
    }

    export class CategoryController {
        public message = 'Hello from category page';
        public category;

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {
            let cId = this.$stateParams['id'];

            this.$http.get('/api/categories/' + cId).then((response) => {
                this.category = response.data;
            })
        }
    }

    export class SubCategoriesController {
        public message = 'Hello from sub Categories page';
        public subCategories;

        constructor(private $http: ng.IHttpService) {
            this.$http.get('/api/subCategories').then((response) => {
                this.subCategories = response.data;
            })
        }
    }

    export class SubCategoryController {
        public message = 'Hello from sub category page';
        public subCategory;

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {
            let scId = this.$stateParams['id'];

            this.$http.get('/api/subCategories/' + scId).then((response) => {
                this.subCategory = response.data;
            })
        }
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
