import Footer from "./Footer";
import Navbar from "./Navbar";

type LayoutProps = {
  children: React.ReactNode;
};

const Layout = ({ children }: LayoutProps) => {
  return (
    <div
      style={{ display: "flex", flexDirection: "column", minHeight: "100vh" }}
    >
      <Navbar />
      <main className="container mx-auto" style={{ flex: 1, padding: "20px" }}>
        {children}
      </main>
      <Footer />
    </div>
  );
};

export default Layout;
