
class SetController {
	constructor($http, $stateParams) {
    this._$http = $http;
		this.sets = [];
		this.subject = $stateParams.subject;
		this.getData();

		// form show/hide thing
		this.newSet = "";
		this.showForm = false;
		this.placeholder = "+";
	}

	toggleForm() {
		this.placeholder = "Add New Set";
		this.showForm = true;
	}

	createSet() {
		this._$http
			.post(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/createset`, {
				Name: this.newSet,
				SubjectId: this.subject
			})
			.then((response) => {
				console.log(response);
				this.newSet = "";
				this.showForm = false;
				this.placeholder = "+";
				this.getData();
			})
			.catch((error) => {
				console.log(error);
			})
		}

  getData() {
		this._$http
		.get(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/viewsubject/${this.subject}`)
		.then((response) => {
			console.log(response);
			this.sets = response.data;
		});
	}

	deleteSet(set) {
	 this._$http
	 .post(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/deleteset/${set.id}`)
	 .then((response) => {
		 this.sets.splice(this.sets.indexOf(set), 1);
	 });
 }





//TEST DATA -------------------------------------------------------------------
		// 	this.cards = [
		// 	{ name: "Test Name",
		// 		id: 5,
		// 		subject: "Test Subject"
		// 	},
		// 	{ name: "Test Name2",
		// 		id: 6,
		// 		subject: "Test Subject"
		// 	}
		// ]
	//-------------------------------------------------------------------

}

export default SetController
