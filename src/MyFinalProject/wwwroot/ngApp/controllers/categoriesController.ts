namespace MyFinalProject.Controllers {

    export class CategoriesController {
        public message = 'Hello from categories page';
        public categories;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            this.$http.get('/api/categories').then((response) => {
                this.categories = response.data;
            })
        }

        public deleteCategory(id: number) {
            this.$http.delete('/api/categories/' + id).then((response) => {
                this.$state.reload();
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
                this.$state.go('categories');
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
        }

        public editCategory() {
            this.$http.post('/api/categories', this.category).then((response) => {
                this.$state.go('categories');
            })
        }
    }
}