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
        public message = 'Hello from the user categories page';
        public userCategory;
        public userSubCategory;

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {
            let userId = this.$stateParams['id'];

            this.$http.get('/api/userCategories/' + userId).then((response) => {
                this.userCategory = response.data;
            })

            this.$http.get('/api/userSubCategories/' + userId).then((response) => {
                this.userSubCategory = response.data;
            })
        }
    }

    export class AddCategoryToUserController {
        public message = 'Hello from add Category to user page';
        public applicationUser;
        public categories;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            let auId = this.$stateParams['id'];

            this.$http.get('/api/userCategories/' + auId).then((response) => {
                this.applicationUser = response.data;
            })

            this.$http.get('/api/categories').then((response) => {
                this.categories = response.data;
            })
        }

        public addCategoryToUser() {
            this.$http.post('/api/userCategories', this.applicationUser).then((response) => {
                this.$state.go('home');
            })
        }
    }

    export class AddCategoryAndSubCategoryToUserController {
        public message = 'Hello from add Category and sub category to user page';
        public applicationUser;
        public categories;
        public subCategories;
        public UserCategory;
        public UserSubCategory;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            let auId = this.$stateParams['id'];

            this.$http.get('/api/userCategories/' + auId).then((response) => {
                this.UserCategory = response.data;
            })

            this.$http.get('/api/userSubCategories/' + auId).then((response) => {
                this.UserSubCategory = response.data;
            })

            this.$http.get('/api/categories').then((response) => {
                this.categories = response.data;
            })

            this.$http.get('/api/subCategories').then((response) => {
                this.subCategories = response.data;
            })
        }

        public addCategoryToUser() {
            this.$http.post('/api/userCategories', this.UserCategory).then((response) => {
                this.$state.go('home');
            })
        }

        public addSubCategoryToUser() {
            this.$http.post('/api/userSubCategories', this.UserSubCategory).then((response) => {
                this.$state.go('home');
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
        public catSubCategory;

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {
            let cId = this.$stateParams['id'];

            this.$http.get('/api/catSubCategories/' + cId).then((response) => {
                this.catSubCategory = response.data;
            })

            this.$http.get('/api/categories/' + cId).then((response) => {
                this.category = response.data;
            })
        }
    }

    export class AddCategoryController {
        public message = 'Hello from add category page';
        public category;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {

        }

        public addCategory() {
            this.$http.post('/api/categories', this.category).then((response) => {
                this.$state.go('home');
            })
        }
    }

    export class EditCategoryController {
        public message = 'Hello from edit category page';
        public category;
        public applicationUsers;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            let cId = this.$stateParams['id'];

            this.$http.get('/api/categories/' + cId).then((response) => {
                this.category = response.data;
            })

            this.$http.get('/api/applicationUsers').then((response) => {
                this.applicationUsers = response.data;
            })
        }

        public addUsers() {
            this.$http.post('/api/categories', this.category).then((response) => {
                this.$state.go('home');
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
