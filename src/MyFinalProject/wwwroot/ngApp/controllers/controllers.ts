namespace MyFinalProject.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
        public appUsers;

        //constructor(private $http: ng.IHttpService) {
        //    this.$http.get('/api/applicationusers').then((response) => {
        //        this.appUsers = response.data;
        //    })
        //}
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
