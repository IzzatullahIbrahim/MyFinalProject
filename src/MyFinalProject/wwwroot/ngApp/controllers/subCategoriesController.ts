namespace MyFinalProject.Controllers {

    export class SubCategoriesController {
        public message = 'Hello from sub Categories page';
        public subCategories;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get('/api/subCategories').then((response) => {
                this.subCategories = response.data;
            })
        }

        public deleteSubCategory(id: number) {
            this.$http.delete('/api/subCategories/' + id).then((response) => {
                this.$state.reload();
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

    export class AddSubCategoryController {
        public message = 'Hello from add Sub Category page';
        public categories;
        public subCategory;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get('/api/Categories').then((response) => {
                this.categories = response.data;
            })
        }

        public addSubCategory() {
            this.$http.post('/api/subCategories', this.subCategory).then((response) => {
                this.$state.go('subCategories');
            })
        }
    }

    export class EditSubCategoryController {
        public message = 'Hello from add Sub Category page';
        public categories;
        public subCategory;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            let scId = this.$stateParams['id'];

            this.$http.get('/api/Categories').then((response) => {
                this.categories = response.data;
            })

            this.$http.get('/api/subCatCategories/' + scId).then((response) => {
                this.subCategory = response.data;
            })
        }

        public editSubCategory() {
            this.$http.post('/api/subCategories', this.subCategory).then((response) => {
                this.$state.go('subCategories');
            })
        }
    }
}