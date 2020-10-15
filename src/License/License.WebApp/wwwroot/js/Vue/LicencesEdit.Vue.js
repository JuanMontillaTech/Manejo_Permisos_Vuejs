var app = new Vue({
    el: '#app',
    data: {
        ListTypeLicense: [],
        errors: [],    
        Id: 0,
        LicenseF:[],
        License: [{
            id: 0,
            licensesType:0,
            fullname: '',
            surnames: '', 
            licensesDate: ''

        }]
    }, components: {
        vuejsDatepicker
    },
    methods: {       
        SaveLicence: function (e) {
            this.errors = [];

            if (!this.License[0].fullname) {
                this.errors.push("El nombre es obligatorio.");
            }
            if (!this.License[0].surnames) {
                this.errors.push("El Apellido es obligatorio.");
            }
            if (!this.License[0].licensesDate) {
                this.errors.push("La Fecha de licencia es obligatoria.");
            }
         
            e.preventDefault();
            if (this.errors.length <1 ) {

                console.log("entro");
                let jsonData = JSON.stringify(this.License[0])
                axios.post("/License/Edit?json=" + jsonData).then(function (response) {
                    toastr.success(response.data)
                    window.location.href = "/License/";
                   
                })
                    .catch(function (error) {
                        console.log(error)
                    });
            }
        },
        SetId: function () {
            var sPageURL = window.location.href;
            var indexOfLastSlash = sPageURL.lastIndexOf("/");
            if (indexOfLastSlash > 0 && sPageURL.length - 1 != indexOfLastSlash)
                this.Id = sPageURL.substring(indexOfLastSlash + 1);
          
        },
        GetLicense: function () {
             
            axios.get("/License/GetLicense?Id=" + this.Id).then(function (response) {
                console.log(response.data.licensesType);
                app.License[0].fullname = response.data.fullName;
                app.License[0].surnames = response.data.surnames;
                app.License[0].licensesType = response.data.licensesType;
                app.License[0].licensesDate = response.data.licensesDate;
                app.License[0].id = response.data.id;
                 

             
        })
            .catch(function (error) {
                console.log(error)
            });

    },



    },
    created: function () {
        axios.get("/LicenseType/GetAllLicenseType").then(function (response) {
          
            app.ListTypeLicense = response.data;
        })
            .catch(function (error) {
                console.log(error)
            });

        this.SetId()
        this.GetLicense()
       
   



    }

})