
class FlashController {

	constructor($http) {
    this._$http = $http;
		// this.id = $stateParams.id;
		this.cards = [];

		this.getData();
	}

	toggleClass(card) {
		if (card.flipped === true) {
			card.flipped = false;
		}
		else {
			card.flipped = true;
		}
	}

  getData() {
		this._$http
		.get(`http://tiy-lr-flashcards.azurewebsites.net/cards/index`)
		.then((response) => {
			console.log(response);
			this.cards = response.data;
		});

		// 	this.cards = [
		// 	{ id: 1,
		// 		frontText: "Title",
		// 		backText: "description"
		// 	},
		// 	{ id: 2,
		// 		frontText: "Title2",
		// 		backText: "description2"
		// 	}
		// ]
		// this._$http
		// .get("New Flashcard")
		// .then((response) => {
    //   console.log(results);
    //   console.log("working");
		// });

  }

}

export default FlashController
