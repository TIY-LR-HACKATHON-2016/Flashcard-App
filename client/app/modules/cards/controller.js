
class FlashController {


	constructor($http) {
    this._$http = $http;

		this.getData();
	}

	toggleClass(card) {
		card.flipped = true;
	}

  getData() {
		this.cards = [
			{ id: 1,
				frontText: "Title",
				backText: "description"
			},
			{ id: 2,
				frontText: "Title2",
				backText: "description2"
			}
		]
		// this._$http
		// .get("New Flashcard")
		// .then((response) => {
    //   console.log(results);
    //   console.log("working");
		// this.cards = response.data.cards;
		// });

  }

}

export default FlashController
