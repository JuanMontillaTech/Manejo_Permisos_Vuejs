var app = new Vue({
    el: '#app',
    data: {
        ListTypeLicense: [],
        errors:[],
        License: [
            {
                Fullname: '',
                Surnames: '',
                LicensesType: -1,
                LicensesDate:''

            }
        ]
    }, components: {
        vuejsDatepicker
    },
    methods: {
        SaveLicence: function (e) {
            this.errors = [];

            if (!this.License[0].Fullname) {
                this.errors.push("El nombre es obligatorio.");
            }
            if (!this.License[0].Surnames) {
                this.errors.push("El Apellido es obligatorio.");
            }
            if (!this.License[0].LicensesDate) {
                this.errors.push("La Fecha de licencia es obligatoria.");
            }
         
            e.preventDefault();
            if (this.errors.length <1 ) {

                console.log("entro");
                let jsonData = JSON.stringify(this.License[0])
                axios.post("/License/Create?json=" + jsonData).then(function (response) {
                    toastr.success(response.data)
                    window.location.href = "/License/";
                   
                })
                    .catch(function (error) {
                        console.log(error)
                    });
            }
        },



    },
    created: function () {
        axios.get("/LicenseType/GetAllLicenseType").then(function (response) {
          
            app.ListTypeLicense = response.data;
        })
            .catch(function (error) {
                console.log(error)
            });

    }

})