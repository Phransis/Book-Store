import React from "react";
// import Logo from '../assets/book-logo.jpg'

function Header() {
  return (
    <>
      <nav className="bg-slate-950 text-white py-4 px-2">
        <div className="flex">
          
            <a href="/">
           <b><span className="text-slate-300 ">Buuk</span><span className="text-slate-500">Staw</span></b> 
 
            </a>
          <div className="container mx-auto px-6 flex items-center justify-center px-6">
            <div className="hidden md:flex space-x-4 ">
              <a href="/about" className="hover:text-gray-600">About</a>
              <a href="/shop" className="hover:text-gray-600">Shop</a>
              <a href="/delivery-team" className="hover:text-gray-600">Delivery Team</a>
              <a href="/sellers" className="hover:text-gray-600">Sellers</a>
            </div>
          </div>
          <a href="/login" className="btn hover:text-sky-700">
            Login
          </a>
        </div>
      </nav>
    </>
  );
}

export default Header;
