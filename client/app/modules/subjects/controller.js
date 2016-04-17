
class SubjectController {
	constructor($http) {
    this._$http = $http;
		this.subjects = [];
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
		.get(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/indexsubject`)
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

	deleteSubject(subject) {
		console.log("trying to delete subject")
	 this._$http
	 .post(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/deletesubject/${subject.id}`)
	 .then((response) => {
		 this.subjects.splice(this.subjects.indexOf(subject), 1);
		 console.log("spliced");
	 });
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
