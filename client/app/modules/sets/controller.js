
class SetController {
	constructor($http, $stateParams) {
    this._$http = $http;
		this.sets = [];
		this.subject = $stateParams.subject;
		this.getData();
	}

	// toggleClass(card) {
	// 	if (card.flipped === true) {
	// 		card.flipped = false;
	// 	}
	// 	else {
	// 		card.flipped = true;
	// 	}
	// }



  getData() {
		this._$http
		.get(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/viewsubject/${this.subject}`)
		.then((response) => {
			console.log(response);
			this.sets = response.data;
		});



//TEST DATA -------------------------------------------------------------------
			this.cards = [
			{ name: "Test Name",
				id: 5,
				subject: "Test Subject"
			},
			{ name: "Test Name2",
				id: 6,
				subject: "Test Subject"
			}
		]
	//-------------------------------------------------------------------

  }

}

export default SetController
