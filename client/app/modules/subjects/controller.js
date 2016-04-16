
class SubjectController {
	constructor($http) {
    this._$http = $http;
		// this.id = $stateParams.id;
		this.subject = [];
		this.getData();

		// form show/hide thing
 		this.newSubject = "";
		this.showForm = false;
		this.placeholder = "+";

	}

	toggleForm() {
		this.placeholder = "Add New Subject";
		this.showForm = true;
	}

	getData() {
		this._$http
		.get(`http://tiy-lr-flashcards.azurewebsites.net/subjects/index`)
		.then((response) => {
			console.log(response);
			this.subject = response.data;
		})
	}



	createSubject() {
		this._$http
			.post('http://tiy-lr-flashcards.azurewebsites.net/subjects/create', {
				Name: this.newSubject
			})
			.then((response) => {
				console.log(response);
				this.newSubject = "";
				this.showForm = false;
				this.placeholder = "+";
				this.getData();
			})
			.catch((error) => {
				console.log(error);
			})


	}

}





export default SubjectController

//TEST DATA -------------------------------------------------------------------
		// 	this.cards = [
		// 	{ name: "Test Name",
		// 		id: 5
		// 	},
		// 	{ name: "Test Name2",
		// 		id: 6
		// 	}
		// ]
	//-------------------------------------------------------------------
