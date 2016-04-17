
class SetController {
	constructor($http, $stateParams) {
    this._$http = $http;
		this.sets = [];
		this.subject = $stateParams.subject;
		this.getData();
	}

	toggleForm() {
		this.placeholder = "Add New Subject";
		this.showForm = true;
	}

	createSet() {
		this._$http
			.post(`http://tiy-lr-flashcards.azurewebsites.net/sets/${this.set}`{
				Name: this.newSet
			})
			.then((response) => {
				console.log(response);
				this.newCard = "";
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
