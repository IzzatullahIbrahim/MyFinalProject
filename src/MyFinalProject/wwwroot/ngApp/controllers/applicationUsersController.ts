namespace MyFinalProject.Controllers {

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

    export class AddCategoryAndSubCategoryToUserController {
        public message = 'Hello from add Category and sub category to user page';
        public applicationUser;
        public categories;
        public subCategories;
        public UserCategory;
        public UserSubCategory;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            let auId = this.$stateParams['id'];
            console.log(auId);

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

    export class EditCategoryAndSubCategoryToUserController {
        public message = 'Hello from Edit Category And Sub Category Controller';
        public applicationUser;
        public categories;
        public subCategories;
        public UserCategory;
        public UserSubCategory;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            let auId = this.$stateParams['id'];
            console.log(auId);

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

        public editCategoryToUser() {
            this.$http.post('/api/userCategories', this.UserCategory).then((response) => {
                this.$state.go('home');
            })
        }

        public editSubCategoryToUser() {
            this.$http.post('/api/userSubCategories', this.UserSubCategory).then((response) => {
                this.$state.go('home');
            })
        }
    }
}