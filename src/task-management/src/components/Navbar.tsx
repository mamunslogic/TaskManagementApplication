import { Link } from "react-router-dom";
import { CustomRoutes } from "./CustomRoutes";

const Navbar = () => {
  return (
    <nav style={styles.navbar}>
      <ul style={styles.navList}>
        {CustomRoutes.map((route, index: number) => (
          <li key={index}>
            <Link style={styles.link} to={route.path}>
              {route.title}
            </Link>
          </li>
        ))}
        {/* <li>
          <Link style={styles.link} to="/">
            Home
          </Link>
        </li>
        <li>
          <Link style={styles.link} to="/project">
            Project
          </Link>
        </li>
        <li>
          <Link style={styles.link} to="/task">
            Task
          </Link>
        </li>
        <li>
          <Link style={styles.link} to="/userlist">
            User List
          </Link>
        </li>
        <li>
          <Link style={styles.link} to="/signup">
            User Registration
          </Link>
        </li> */}
      </ul>
    </nav>
  );
};

const styles = {
  navbar: { background: "#282c34", padding: "10px" },
  navList: { listStyleType: "none", display: "flex", margin: 0, padding: 0 },
  link: { color: "white", textDecoration: "none", margin: "0 10px" },
};

export default Navbar;
