open System

type EnrollmentStatus =
    | NotEnrolled
    | PortalEnabled of DateTime
    | EmailSent of string * DateTime
    | EnrollmentError of string list
    | Enrolled of DateTime

