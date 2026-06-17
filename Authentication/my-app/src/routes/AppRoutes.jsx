import { Routes, Route } from "react-router";
import Hero from '../pages/home/Home';
import Contact from '../pages/contact/Contact';
import About from '../pages/about/About';
import SignUp from "../components/signUp/SignUp";

const AppRoutes = () => {
    return (
        <>
            <Routes>
                <Route path="/home" element={<Hero />} />
                <Route path="/about-us" element={<About />} />
                <Route path="/contact-us" element={<Contact />} />
                <Route path="/sign-up" element={<SignUp />} />
            </Routes>
        </>
    )
}

export default AppRoutes;



