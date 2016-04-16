
class SetController {
	constructor($http) {
    this._$http = $http;
		// this.id = $stateParams.id;
		this.cards = [];
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
		.get(`http://tiy-lr-flashcards.azurewebsites.net/cards/index`)
		.then((response) => {
			console.log(response);
			this.cards = response.data;
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
