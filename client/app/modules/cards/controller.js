
class FlashController {


	constructor($http) {
    this._$http = $http;

		this.getData();
	}

  getData() {
		this.cards = [
			{ id: 1,
				frontText: "Bob",
				backText: "Smith"
			},
			{ id: 2,
				frontText: "Joe",
				backText: "Whatever"
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
