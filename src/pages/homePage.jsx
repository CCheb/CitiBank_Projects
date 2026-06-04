import Navbar from "../components/navBar";

function HomePage() {
  return (
    <>
      <Navbar />

      <div className="container">
        <h1>Welcome to Bank App</h1>

        <p>
          This frontend will connect to our ASP.NET BankAPI backend.
        </p>
      </div>
    </>
  );
}

export default HomePage;