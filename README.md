# 📚 BookStoreAPI

A RESTful API for managing a bookstore's inventory, built with ASP .Net Core Framework.

## 🚀 Features

- **Book Management:** Add, retrieve, update, and delete books.
- **Author Management:** Manage author details.
- **Category Management:** Organize books into categories.

## 🛠️ Tech Stack

- **Backend:** ASP .Net Core, ASP .Net Core Framework
- **Database:** SQLite (default, can be configured for PostgreSQL, MySQL, etc.)

## 📦 Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/Abdelrahman984/BookStoreAPI.git
   cd BookStoreAPI/BookStoreAPI
   ```

2. **Create and activate a virtual environment:**

   ```bash
   python -m venv env
   source env/bin/activate  # On Windows, use `env\Scripts\activate`
   ```

3. **Install dependencies:**

   ```bash
   pip install -r requirements.txt
   ```

4. **Apply migrations:**

   ```bash
   python manage.py migrate
   ```

5. **Create a superuser (optional, for admin access):**

   ```bash
   python manage.py createsuperuser
   ```

6. **Start the development server:**

   ```bash
   python manage.py runserver
   ```

   The API will be accessible at `http://127.0.0.1:8000/`.

## 📄 API Endpoints

The API provides the following endpoints:

- **Books:**
  - `GET /api/books/` - List all books
  - `POST /api/books/` - Create a new book
  - `GET /api/books/{id}/` - Retrieve a book by ID
  - `PUT /api/books/{id}/` - Update a book by ID
  - `DELETE /api/books/{id}/` - Delete a book by ID

- **Authors:**
  - `GET /api/authors/` - List all authors
  - `POST /api/authors/` - Create a new author
  - `GET /api/authors/{id}/` - Retrieve an author by ID
  - `PUT /api/authors/{id}/` - Update an author by ID
  - `DELETE /api/authors/{id}/` - Delete an author by ID

- **Categories:**
  - `GET /api/categories/` - List all categories
  - `POST /api/categories/` - Create a new category
  - `GET /api/categories/{id}/` - Retrieve a category by ID
  - `PUT /api/categories/{id}/` - Update a category by ID
  - `DELETE /api/categories/{id}/` - Delete a category by ID

## 🧪 Running Tests

To run tests for the application:

```bash
python manage.py test
```

## 🔒 Authentication

The API uses token-based authentication. Obtain a token by providing valid user credentials:

```bash
POST /api/token/
```

Include the token in the `Authorization` header for authenticated requests:

```
Authorization: Token your_token_here
```

## 📄 License


