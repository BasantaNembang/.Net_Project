import { NavLink } from 'react-router-dom';

const Navbar = () => {
    return (
        <>
            <ul>
                <NavLink to="/home"> Home</NavLink>
                <NavLink to="/about-us"> About-Us</NavLink>
                <NavLink to="/contact-us"> Contact-Us</NavLink>
                <NavLink to="/sign-up"> Sign-Up</NavLink>
            </ul>
        </>
    )
}

export default Navbar;

