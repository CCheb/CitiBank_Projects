import { Link } from "react-router-dom";

function Navbar() {
    return (
        <nav>
            <Link to="/">Home</Link>{" "}
            <Link to="/customers">Customers</Link>{" "}
            <Link to="/customers/search">Search Customer</Link>{" "}
            <Link to="/customers/create">Create Customer</Link>
        </nav>
    );
}

export default Navbar;