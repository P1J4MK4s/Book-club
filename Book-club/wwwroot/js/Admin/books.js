var app = new Vue({
    el: '#app',
    data: {
        editing: false,
        loading: false,
        objectIndex: 0,
        bookModel: {
            id: 0,
            title: "Book Title",
            author: "Book Author",
            description: "Book Description",
        },
        books: []
},
    mounted() {
    this.getBooks();
},
    methods: {
    getBook(id) {
        this.loading = true;
        axios.get('/Admin/books/' + id)
            .then(res => {
                console.log(res);
                var book = res.data;
                this.bookModel = {
                    id: book.id,
                    title: book.title,
                    author: book.author,
                    description: book.description,
                }
            })
            .catch(err => {
                console.log(err);
            })
            .then(() => {
                this.loading = false;
            });
    },

    getBooks() {
        this.loading = true;
        axios.get('/Admin/books')
            .then(res => {
                console.log(res);
                this.books = res.data;
            })
            .catch(err => {
                console.log(err);
            })
            .then(() => {
                this.loading = false;
            });
    },

    createBook() {
        this.loading = true;
        axios.post('/Admin/books', this.bookModel)
            .then(res => {
                console.log(res.data);
                this.books.push(res.data)
            })
            .catch(err => {
                console.log(err);
            })
            .then(() => {
                this.loading = false;
                this.editing = false;
            });
    },
    updateBook() {
        this.loading = true;
        axios.put('/Admin/books', this.bookModel)
            .then(res => {
                console.log(res.data);
                this.books.splice(this.objectIndex, 1, res.data)
            })
            .catch(err => {
                console.log(err);
            })
            .then(() => {
                this.loading = false;
                this.editing = false;
            });
    },
    deleteBook(id, index) {
        this.loading = true;
        axios.delete('/Admin/books/' + id)
            .then(res => {
                console.log(res);
                this.books.splice(index, 1);
            })
            .catch(err => {
                console.log(err);
            })
            .then(() => {
                this.loading = false;
            });
    },
    newBook() {
        this.editing = true;
        this.bookModel.id = 0;
    },
    editBook(id, index) {
        this.objectIndex = index;
        this.getBook(id);
        this.editing = true;
    },
    cancel() {
        this.editing = false;
    }
},
});