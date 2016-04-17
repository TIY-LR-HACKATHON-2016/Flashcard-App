
class FlashController {

	constructor($http, $stateParams) {
    this._$http = $http;
		this.set = $stateParams.set;
		// this.id = $stateParams.id;
		this.cards = [];
		this.getData();

		// form show/hide thing
		this.newSubject = "";
		this.showForm = false;
		this.placeholder = "+";

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
		.get(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/viewset/${this.set}`)
		.then((response) => {
			console.log(response);
			this.cards = response.data;
		});
	}

		createCard() {
			this._$http
				.post(`http://tiy-lr-flashcards.azurewebsites.net/cards/${this.card}`{
					Name: this.newCard
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

//TEST DATA -------------------------------------------------------------------
		// 	this.cards = [
		// 	{ id: 1,
		// 		FrontText: "Title",
		// 		BackText: "description"
		// 	},
		// 	{ id: 2,
		// 		FrontText: "Title2",
		// 		BackText: "description2"
		// 	}
		// ]
	//-------------------------------------------------------------------

  }


export default FlashController
