import "./App.css";
import { Route, BrowserRouter as Router, Routes } from "react-router-dom";
import Layout from "./components/Layout";
import HomePage from "./pages/HomePage";
import About from "./pages/About";
import Shop from "./pages/Shop";
import Sellers from "./pages/Sellers";
import DeliveryTeam from "./pages/DeliveryTeam";
import Login from "./pages/Login";
import Register from "./pages/Register";

function App() {
  return (
  <>
  <Router>
    <Routes>
      <Route path="/" element={<Layout/>}>
        <Route index element={<HomePage/>}></Route>
        <Route path="/about" element={<About/>}></Route>
        <Route path="/shop" element={<Shop/>}></Route>
        <Route path="/sellers" element={<Sellers/>}></Route>
        <Route path="/delivery-team" element={<DeliveryTeam/>}></Route>
        <Route path="/login" element={<Login/>}></Route>
        <Route path="/register" element={<Register/>}></Route>
      </Route>
    </Routes>
  </Router>
  </>
  );
}

export default App;
