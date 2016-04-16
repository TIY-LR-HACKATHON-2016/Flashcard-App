
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


	addClass(active) {
		//add class active on click
	}




  getData() {
		// this._$http
		// .get(`http://tiy-lr-flashcards.azurewebsites.net/subjects/create`)
		// .then((response) => {
		// 	console.log(response);
		// 	this.cards = response.data;
		// });



//TEST DATA -------------------------------------------------------------------
			this.cards = [
			{ name: "Test Name",
				id: 5
			},
			{ name: "Test Name2",
				id: 6
			}
		]
	//-------------------------------------------------------------------

  }

	createSubject() {
		console.log("subject created");

		this._$http
			.post('http://tiy-lr-flashcards.azurewebsites.net/subjects/create', {
				Name: "test"
			})
			.then((response) => {
				console.log(response);
			})
			.catch((error) => {
				console.log(error);
			})

	}

}

export default SubjectController
