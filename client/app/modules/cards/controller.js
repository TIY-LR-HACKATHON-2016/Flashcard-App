
class FlashController {

	constructor($http, $stateParams) {
    this._$http = $http;
		this.set = $stateParams.set;
		// this.id = $stateParams.id;
		this.cards = [];
		this.getData();
		// form show/hide //
		this.newCardFront = "";
		this.newCardBack = "";
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

	toggleEditing(set) {
		if (set.editing === true) {
			set.editing = false;
		}
		else {
			set.editing = true;
		}
		console.log(set);

	}

	createCard() {
		this._$http
			.post(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/createcard`, {
				frontText: this.newCardFront,
				backText: this.newCardBack,
				SetId: this.set
			})
			.then((response) => {
				console.log(response);
				this.newCardFront = "";
				this.newCardBack = "";
				this.showForm = false;
				this.placeholder = "+";
				this.getData();
			})
			.catch((error) => {
				console.log(error);
			})
		}

	toggleForm() {
		this.placeholder = "New Card Front";
		this.showForm = true;
	}

  getData() {
		this._$http
		.get(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/viewset/${this.set}`)
		.then((response) => {
			console.log(response);
			this.cards = response.data;
		});
	}

	deleteCard(card) {
	 this._$http
	 .post(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/deletecard/${card.id}`)
	 .then((response) => {
		 this.cards.splice(this.cards.indexOf(card), 1);
	 });
 }

 editCard(card) {
	this._$http
	.post(`http://tiy-lr-flashcards.azurewebsites.net/flashcards/editcard/${card.id}`, {
		Name: card.name
	})
	.then((response) => {
		console.log(response);
		card.editing = false;
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
