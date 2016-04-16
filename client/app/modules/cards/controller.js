
class FlashController {


	constructor($http, $stateParams) {
    this._$http = $http;
		this.id = $stateParams.id;

		this.getData();
	}

  getData() {
		this.cards = [
			{ id: 1,
				frontText: "Bob",
				backText: "Smith"
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
