import React from "react";
import Book from "../assets/book-logo.jpg";
import Book1 from "../assets/book1.webp";
import { BOOKS } from "../Services/API";
function HomePage() {
  return (
    <>
      <div>
        <section
          className="relative bg-cover bg-center h-screen"
          style={{ backgroundImage: `url(${Book})` }}
        >
          <div className="absolute inset-0 bg-blue-900 opacity-50"></div>{" "}
          {/* Blue overlay with transparency */}
          <div className="relative z-10 flex items-center justify-center h-full">
            <div className="text-center text-white">
              <h1 className="sm:text-5xl hero-section  font-bold  mt-12">
                The Book Lover's Dreamland Awaits!
              </h1>
              <p className="text-center text-lg  mt-4 mb-4 px-12 hero-section1">
                Welcome to the ultimate book lover's paradise! Join our
                community and contribute to the ever-evolving library of
                stories, where every book has a chance to inspire someone new..
              </p>
              <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded mr-2">
                <a href="shop"> Explore More Books </a>
              </button>
              <button className="bg-transparent border border-white hover:bg-white hover:text-blue-900 text-white font-bold py-2 px-4 rounded">
                <a href="about">Learn More!!</a>
              </button>
            </div>
          </div>
        </section>

        <section>
          <div className="container mx-auto px-12">
            <div className="container mx-auto px-12">Ok</div>
          </div>
        </section>

        <section className="container mx-auto px-2">
          <div>Our Best Picks..</div>
          <div className="container mx-auto px-2 mb-4 flex flex-wrap gap-12">
            {BOOKS.map((book, index) => (
              <div key={index} className="w-full sm:w-1/2 md:w-1/3 lg:w-1/6 ">
                <div className="bg-white p-6 rounded-lg shadow-md">
                  <img
                    src={book.image}
                    alt="book"
                    className="w-full h-48 object-cover rounded-lg mb-4"
                  ></img>
                  <div>
                    <h3 className="text-lg font-semibold">Title: {book.book_name}</h3>
                    <h3 className="text-sm text-gray-500">Author: {book.author}</h3>
                    <h3 className="text-sm text-gray-700 font-bold">Ratings: {book.ratings}</h3>
                    <h3 className="text-sm text-gray-600 mt-2">Genre: {book.tags[2]}</h3>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </section>
      </div>
    </>
  );
}

export default HomePage;
